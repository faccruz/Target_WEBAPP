using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Web.Mvc;
using Target_WEBAPP.Models;

namespace Target_WEBAPP.Controllers
{
    public class HomeController : Controller
    {
        string UrlBase = System.Configuration.ConfigurationManager.AppSettings["BaseAddress"];
        public ActionResult Index()
        {
            List<TargetAgenda> agenda = GetAll();
            return View(agenda);
        }

        public List<TargetAgenda> GetAll()
        {
            var client = new RestClient(UrlBase);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            List<TargetAgenda> agenda = JsonConvert.DeserializeObject<List<TargetAgenda>>(response.Content);

            return agenda;
        }

        public TargetAgenda GetById(int id)
        {
            var client = new RestClient(UrlBase + "/" + id);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            TargetAgenda agenda = JsonConvert.DeserializeObject<TargetAgenda>(response.Content);
            return agenda;
        }

        public ActionResult NewAgenda(int id)
        {

            if (id == 0)
            {
                ViewBag.btnValue = "Gravar";
                return View();
            }                
            else
            {
                //recuperar dados da agenda
                TargetAgenda agenda = GetById(id);
                ViewBag.btnValue = "Atualizar";
                return View(agenda);
            }
        }

        public ActionResult Delete(int id)
        {
            var client = new RestClient(UrlBase + "/" + id);

            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            IRestResponse response = client.Execute(request);
            
            return RedirectToAction("index");
        }

        public ActionResult SalvarAgenda(TargetAgenda agenda)
        {
            var client = new RestClient(UrlBase);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            var json = JsonConvert.SerializeObject(agenda);

            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return RedirectToAction("index");
        }

        public ActionResult AtualizarDados(TargetAgenda agenda, int id)
        {
            var client = new RestClient(UrlBase + "/" + id);
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            var json = JsonConvert.SerializeObject(agenda);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return RedirectToAction("index");
        }

    }
}