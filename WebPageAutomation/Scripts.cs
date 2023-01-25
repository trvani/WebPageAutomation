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
                                  $('#' + formId).submit();
                              }";



        //public static string SelectMakeScript = @"document.getElementById('makes').value = 'tesla';";
        public static string SelectMakeScript = @"
                              var select = document.getElementById('makes');
                              for(var i=0; i < elmnt.options.length; i++)
                              {
                                if(elmnt.options[i].value === 'tesla') {
                                  elmnt.selectedIndex = i;
                                  break;
                                }
                              }";
        
        
       // public static string SelectModelScript = @"document.getElementById('models').value = 'tesla-model_s';";
        public static string SelectModelScript = @"var tm = 'tesla-model_s';
                              var select = document.getElementById('models');
                              for (var i = 0; i < select.children.length; i++)
                              {
                                  var v = select.children[i].value;
                                  var cp = tm.localeCompare(v);
                                  if (cp == 0)
                                  {
                                       select.children[i].selected = true;   
                                  }
                              }";

        public static string SelectPriceScript = @"var tm = '100000';"+Environment.NewLine+ @"var select = document.getElementById('make-model-max-price');"+Environment.NewLine+ @" for (var i = 0; i < select.children.length; i++) "+Environment.NewLine+@"{var v = select.children[i].text; "+Environment.NewLine+@"var cp = tm.localeCompare(v); "+Environment.NewLine+@"if (cp == 0){ select.children[i].selected = true; }}";
        public static string FillZIO = string.Format("$('input[type=email]').val('johngerson808@gmail.com'); ('input[type=password]').val('test8008'); $('button').click();");
    }
}
