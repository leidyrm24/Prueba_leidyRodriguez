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
    public class CITYSController : Controller
    {
        String api = "https://localhost:44354/api/CITY/";

        #region citys
        async Task<List<CITY>> citys()
        {
            List<CITY> ListCity = new List<CITY>();
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(api);
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

        #region Metodos CRUD
        public async Task<IActionResult> Index()
        {
            ViewBag.citys = await citys();
            ViewBag.titulo = "Agregar";
            return View(await Task.Run(() => new CITY()));
        }

        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.citys = await citys();
            ViewBag.titulo = "Actualizar";
            CITY reg = new CITY();
            foreach (CITY bean in ViewBag.citys)
            {
                if ((bean.CODE + "") == id)
                {
                    reg = bean;
                    break;
                }
            }
            return View("Index", await Task.Run(() => reg));
        }


        [HttpPost]
        public async Task<IActionResult> Agregar(CITY reg)
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
                    mensaje = "CITY Recording ";
                }
            }
            ViewBag.mensaje = mensaje;
            ViewBag.citys = await citys();
            ViewBag.titulo = "Agregar";
            return View("Index", await Task.Run(() => new CITY()));
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(CITY reg)
        {
            string mensaje = "";
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(api);

                StringContent contenido = new StringContent(
                JsonConvert.SerializeObject(reg), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage respuesta = await cliente.PostAsync("UpdateCity", contenido);
                if (respuesta.IsSuccessStatusCode)
                {
                    mensaje = await respuesta.Content.ReadAsStringAsync();
                }
            }
            ViewBag.mensaje = mensaje;
            ViewBag.citys = await citys();
            ViewBag.titulo = "Agregar";
            return View("Index", await Task.Run(() => new CITY()));

        }

        public async Task<IActionResult> Delete(string id)
        {
            ViewBag.citys = await citys();
            ViewBag.titulo = "Eliminar";
            CITY reg = new CITY();
            foreach (CITY bean in ViewBag.citys)
            {
                if ((bean.CODE + "") == id)
                {
                    reg = bean;
                    break;
                }
            }

            return View("Index", await Task.Run(() => reg));
        }


        [HttpPost]
        public async Task<IActionResult> Eliminar(CITY reg)
        {
            string mensaje = "";
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(api);

                StringContent contenido = new StringContent(
                JsonConvert.SerializeObject(reg), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage respuesta = await cliente.PostAsync("DeleteCity", contenido);
                if (respuesta.IsSuccessStatusCode)
                {
                    mensaje = await respuesta.Content.ReadAsStringAsync();
                }
            }
            ViewBag.mensaje = mensaje;
            ViewBag.citys = await citys();
            ViewBag.titulo = "Agregar";
            return View("Index", await Task.Run(() => new CITY()));

        }
        #endregion

    }
}
