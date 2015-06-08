using System.Web.Mvc;
using PairingTest.Web.Models;
using System.ServiceModel;
using QuestionnaireContracts;
using Utils;
using QuestionnaireLibrary;
using System;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
          /* ASYNC ACTION METHOD... IF REQUIRED... */
//        public async Task<ViewResult> Index()
//        {
//        }
      
        public ViewResult Index()
        {
            Questionnaire questionnaire = null;
            WCFproxy<IQuestionService>.Use(client =>
                {
                    questionnaire = client.GetQuestionaire();
                });
            ViewBag.EditMode = true;
            return View(questionnaire);
        }

        [HttpPost]
        public ViewResult Index(Questionnaire questionnaire)
        {
            User user = new User();
            if (this.User != null && User.Identity != null)
            {
                user.Name = this.User.Identity.Name;
                if (user.Name.Length == 0)
                    user.Name = ClientIP() + ";" + DateTime.Now.ToString("yyMMddHHmmss");
            }
            else
                user.Name = ClientIP() + ";" + DateTime.Now.ToString("yyMMddHHmmss");
           
            WCFproxy<IQuestionService>.Use(client =>
            {
                questionnaire = client.SaveAndValidateQuestionnaire(questionnaire, user);
            });
            ViewBag.EditMode = false;
            return View(questionnaire);
        }

        private string ClientIP()
        {
            if (Request!=null)
            return (Request.UserHostAddress == "::1" ? "127.0.0.1" : Request.UserHostAddress);
            else
                return "127.0.0.1";
        }
    }
}
