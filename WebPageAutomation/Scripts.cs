using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageAutomation
{
    public static class Scripts
    {
        public static string LoginScript = string.Format("$('input[type=email]').val('johngerson808@gmail.com'); ('input[type=password]').val('test8008'); $('button').click();");
        public static string SelectUsageScript = @"var tm = 'Used';
                              var select = document.getElementById('make-model-search-stocktype');
                              for (var i = 0; i < select.children.length; i++)
                              {
                                  var v = select.children[i].text;
                                  var cp = tm.localeCompare(v);
                                  if (cp == 0)
                                  {
                                       select.children[i].selected = true;
                                  }
                              }";

        public static string SelectMakeScript = @"var tm = 'Tesla';
                              var select1 = document.getElementById('makes');
                              for (var i = 0; i < select1.children.length; i++)
                              {
                                  var v = select1.children[i].text;
                                  var cp = tm.localeCompare(v);
                                  if (cp == 0)
                                  {
                                       select1.children[i].selected = true;
                                  }
                              }";


        public static string SelectModelScript = @"var tm = 'Model S';
                              var select2 = document.getElementById('models');
                              for (var i = 0; i < select2.children.length; i++)
                              {
                                  var v = select2.children[i].text;
                                  var cp = tm.localeCompare(v);
                                  if (cp == 0)
                                  {
                                       select2.children[i].selected = true;
                                  }
                              }";

        public static string SelectPriceScript = @"var tm = '100000';"+Environment.NewLine+ @"var select = document.getElementById('make-model-max-price');"+Environment.NewLine+ @" for (var i = 0; i < select.children.length; i++) "+Environment.NewLine+@"{var v = select.children[i].text; "+Environment.NewLine+@"var cp = tm.localeCompare(v); "+Environment.NewLine+@"if (cp == 0){ select.children[i].selected = true; }}";
        public static string FillZIO = string.Format("$('input[type=email]').val('johngerson808@gmail.com'); ('input[type=password]').val('test8008'); $('button').click();");
    }
}
