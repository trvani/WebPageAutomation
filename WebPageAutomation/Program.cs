using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp.OffScreen;
using CefSharp;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace WebPageAutomation
{
    public class Program
    {

        public static void Main(string[] args)
        {
#if ANYCPU
            //Only required for PlatformTarget of AnyCPU
            CefRuntime.SubscribeAnyCpuAssemblyResolver();
#endif


            const string testUrl = "https://www.cars.com";

            Console.WriteLine("You may see Chromium debugging output, please wait...");
            Console.WriteLine();

            AsyncContext.Run(async delegate
            {
                var settings = new CefSettings()
                {
                    //By default CefSharp will use an in-memory cache, you need to specify a Cache Folder to persist data
                    CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache"),
                    WindowlessRenderingEnabled=true
                    
                };

               // settings.CefCommandLineArgs.Add("disable-web-security","disable-web-security");

                //Perform dependency check to make sure all relevant resources are in our output directory.
                var success = await Cef.InitializeAsync(settings, performDependencyCheck: true, browserProcessHandler: null);

                if (!success)
                {
                    throw new Exception("Unable to initialize CEF, check the log file.");
                }

                // Create the CefSharp.OffScreen.ChromiumWebBrowser instance
                using (var browser = new ChromiumWebBrowser(testUrl))
                {
                    var initialLoadResponse = await browser.WaitForInitialLoadAsync();

                    if (!initialLoadResponse.Success)
                    {
                       // throw new Exception(string.Format("Page load failed with ErrorCode:{0}, HttpStatusCode:{1}", initialLoadResponse.ErrorCode, initialLoadResponse.HttpStatusCode));
                    }


                    await browser.EvaluateScriptAsync(Scripts.LoginScript);
                    await Task.Delay(1000);
              
                    // string scr = Scripts.SelectPriceScript+ $"('button').click();";
                    await browser.EvaluateScriptAsync(Scripts.SelectUsageScript);
                 

                    //Give the browser a little time to render
                    await Task.Delay(4000);

                    await browser.EvaluateScriptAsync(Scripts.SelectMakeScript);
                    
                    //Give the browser a little time to render
                    await Task.Delay(4000);

                    await browser.EvaluateScriptAsync(Scripts.SelectModelScript);

        
                  

                    //Give the browser a little time to render
                    await Task.Delay(4500);
                    // Wait for the screenshot to be taken.
                    var bitmapAsByteArray = await browser.CaptureScreenshotAsync();

                    // Filath to save our screenshot e.g. C:\Users\{username}\Desktop\CefSharp screenshot.png
                    var screenshotPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CefSharp screenshot.png");

                    Console.WriteLine();
                    Console.WriteLine("Screenshot ready. Saving to {0}", screenshotPath);

                    File.WriteAllBytes(screenshotPath, bitmapAsByteArray);

                    Console.WriteLine("Screenshot saved. Launching your default image viewer...");

                    // Tell Windows to launch the saved image.
                    Process.Start(new ProcessStartInfo(screenshotPath)
                    {
                        // UseShellExecute is false by default on .NET Core.
                        UseShellExecute = true
                    });

                    Console.WriteLine("Image viewer launched. Press any key to exit.");
                }

                // Wait for user to press a key before exit
                Console.ReadKey();

                // Clean up Chromium objects. You need to call this in your application otherwise
                // you will get a crash when closing.
                Cef.Shutdown();
            });


            Console.ReadLine();
        }

        //public static async void InitBrowser()
        //{
            
            
        //    var sett = new CefSettings();
            
        //    browser = new ChromiumWebBrowser((CefSharp.Web.HtmlString)"https://www.cars.com/");
            
        //    browser.LoadingStateChanged += (sender, args) => { if (!browser.IsLoading) are.Set(); };
        //    //browser.Load("https://www.cars.com/");
        //    are.WaitOne();
        //    await browser.WaitForInitialLoadAsync();
        //}

        //public static async void FillLoginForm(string UserName, string Password)
        //{
        //    //await Task.Run(()=> browser.ExecuteScriptAsync("document.getElementsByClassName('nav-user-menu-button').click()"));

        //   // browser.ExecuteScriptAsync($"window.open('{}','_blank')");
        //    //browser.ExecuteScriptAsync($"document.getElementById('auth-modal-current-password').value={Password}'");
        //    ////browser.ExecuteScriptAsync("document.getElementsByTagName('button')[0].click();");
        //    //browser.ExecuteScriptAsync("document.getElementsByTagName('button')[0].click();");
        //    string script0 = string.Format("$('input[type=email]').val('johngerson808@gmail.com'); ('input[type=password]').val('test8008'); $('button').click();");

        //    string script = @"var tm = 'Used';
        //                      var select = document.getElementById('make-model-search-stocktype');
        //                      for (var i = 0; i < select.children.length; i++)
        //                      {
        //                          var v = select.children[i].text;
        //                          var cp = tm.localeCompare(v);
        //                          if (cp == 0)
        //                          {
        //                               select.children[i].selected = true;
        //                          }
        //                      }";

        //    await browser.EvaluateScriptAsync(script);
        //    await browser.EvaluateScriptAsync(script0);
        //    are.WaitOne();
        //    await browser.WaitForInitialLoadAsync();

        //    Console.WriteLine(await browser.GetSourceAsync());
        //}
    }
}
