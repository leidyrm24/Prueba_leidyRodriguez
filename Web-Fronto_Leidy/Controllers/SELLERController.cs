using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web_Front_Leidy.Models;

namespace Web_Front_Leidy.Controllers
{
    public class SELLERController : Controller
    {
        String api = "https://localhost:44354/api/SELLER/";

        String api_city = "https://localhost:44354/api/CITY/";

        #region citys
        async Task<List<CITY>> citys()
        {
            List<CITY> ListCity = new List<CITY>();
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(api_city);
                HttpResponseMessage mensaje = await cliente.GetAsync("List");
                if (mensaje.IsSuccessStatusCode)
                {
                    string respuesta = await mensaje.Content.ReadAsStringAsync();
                    ListCity = JsonConvert.DeserializeObject<List<CITY>>(respuesta);
                }
            }
            return ListCity;
        }

        #endregion

        #region seller
        async Task<List<SELLER>> seller()
        {
            List<SELLER> ListSeller = new List<SELLER>();
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(api);
                HttpResponseMessage mensaje = await cliente.GetAsync("List");
                if (mensaje.IsSuccessStatusCode)
                {
                    string respuesta = await mensaje.Content.ReadAsStringAsync();
                    ListSeller = JsonConvert.DeserializeObject<List<SELLER>>(respuesta);
                }
            }
            return ListSeller;
        }

        #endregion

        #region Metodos CRUD
        public async Task<IActionResult> Index()
        {
            ViewBag.seller = await seller();
            ViewBag.titulo = "Agregar";
            ViewBag.citys = new SelectList(await citys(), "CODE", "DESCRIPCTION");

            return View(await Task.Run(() => new SELLER()));
        }


        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.seller = await seller();
            ViewBag.titulo = "Actualizar";
            SELLER reg = new SELLER();
            foreach (SELLER bean in ViewBag.seller)
            {
                if ((bean.CODE + "") == id)
                {
                    reg = bean;
                    break;
                }
            }
            ViewBag.citys = new SelectList(await citys(), "CODE", "DESCRIPCTION");
            return View("Index", await Task.Run(() => reg));
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(SELLER reg)
        {
            string mensaje = "";
            using (var cliente = new HttpClient())
            {

                cliente.BaseAddress = new Uri(api);
                StringContent contenido = new StringContent(
                JsonConvert.SerializeObject(reg), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage respuesta = await cliente.PostAsync("CreateRecord", contenido);
                if (respuesta.IsSuccessStatusCode)
                {
                    mensaje = "SELLER Recording ";
                }
            }
            ViewBag.mensaje = mensaje;
            ViewBag.seller = await seller();
            ViewBag.titulo = "Agregar";
            ViewBag.citys = new SelectList(await citys(), "CODE", "DESCRIPCTION");
            return View("Index", await Task.Run(() => new SELLER()));
        }


        [HttpPost]
        public async Task<IActionResult> Actualizar(SELLER reg)
        {
            string mensaje = "";
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(api);

                StringContent contenido = new StringContent(
                JsonConvert.SerializeObject(reg), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage respuesta = await cliente.PostAsync("UpdateSeller", contenido);
                if (respuesta.IsSuccessStatusCode)
                {
                    mensaje = "SELLER Update";
                }
            }
            ViewBag.mensaje = mensaje;
            ViewBag.seller = await seller();
            ViewBag.titulo = "Agregar";
            ViewBag.citys = new SelectList(await citys(), "CODE", "DESCRIPCTION");
            return View("Index", await Task.Run(() => new SELLER()));

        }

        public async Task<IActionResult> Delete(string id)
        {
            ViewBag.seller = await seller();
            ViewBag.titulo = "Eliminar";
            SELLER reg = new SELLER();
            foreach (SELLER bean in ViewBag.seller)
            {
                if ((bean.CODE + "") == id)
                {
                    reg = bean;
                    break;
                }
            }
            ViewBag.citys = new SelectList(await citys(), "CODE", "DESCRIPCTION");
            return View("Index", await Task.Run(() => reg));
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(SELLER reg)
        {
            string mensaje = "";
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(api);

                StringContent contenido = new StringContent(
                JsonConvert.SerializeObject(reg), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage respuesta = await cliente.PostAsync("DeleteSeller", contenido);
                if (respuesta.IsSuccessStatusCode)
                {
                    mensaje = await respuesta.Content.ReadAsStringAsync();
                }
            }
            ViewBag.mensaje = mensaje;
            ViewBag.seller = await seller();
            ViewBag.titulo = "Agregar";
            ViewBag.citys = new SelectList(await citys(), "CODE", "DESCRIPCTION");
            return View("Index", await Task.Run(() => new SELLER()));

        }

        #endregion

    }
}
