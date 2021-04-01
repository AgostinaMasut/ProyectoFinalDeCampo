using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LolaApp.DataAccess;
using LolaApp.DataAccess.Replositories;
using LolaApp.Entities;
using LolaApp.WebUI.Models;

namespace LolaApp.WebUI.Controllers
{
    public class SexoController : Controller
    {
        private readonly ISexoRepository _sexoRepository;

        public SexoController()
        {
            _sexoRepository = new SexoRepository(new LolaAppContext());
        }
        //public SexoController(ISexoRepository sexoRepository)
        //{
        //    _sexoRepository = sexoRepository;
        //}
        // GET: Sexo
        public ActionResult Index()
        {
            var entityListado = _sexoRepository.FindBy(registro => registro.Deshabilitado == false);
            var modelListado = new List<SexoViewModel>();
            ///TODO: Usar componente para mapear
            foreach (var item in entityListado) {
                var model = new SexoViewModel();
                model.Id = item.Id;
                model.Denominacion = item.Denominacion;
                modelListado.Add(model);
            }

            return View(modelListado);
        }

        // GET: Sexo/Details/5
        public ActionResult Details(int id)
        {
            var entity = _sexoRepository.GetById(id);
            var model = new SexoViewModel();
            model.Id = entity.Id;
            model.Denominacion = entity.Denominacion;
            return View(model);
        }

        // GET: Sexo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sexo/Create
        [HttpPost]
        public ActionResult Create(SexoViewModel model)
        {
            try
            {
                if (ModelState.IsValid==false)
                {
                    return View(model);
                }
                var entity = new Sexo();
                entity.Denominacion = model.Denominacion;
                _sexoRepository.Create(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sexo/Edit/5
        public ActionResult Edit(int id)
        {
            var entity = _sexoRepository.GetById(id);
            var model = new SexoViewModel();
            model.Id = entity.Id;
            model.Denominacion = entity.Denominacion;
            return View(model);
        }

        // POST: Sexo/Edit/5
        [HttpPost]
        public ActionResult Edit(SexoViewModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }
                var entity = new Sexo();
                entity.Id = model.Id;
                entity.Denominacion = model.Denominacion;
                _sexoRepository.Update(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sexo/Delete/5
        public ActionResult Delete(int id)
        {
            var entity = _sexoRepository.GetById(id);
            var model = new SexoViewModel();
            model.Id = entity.Id;
            model.Denominacion = entity.Denominacion;
            return View(model);
        }

        // POST: Sexo/Delete/5
        [HttpPost]
        public ActionResult Delete(SexoViewModel model)
        {
            try
            {
                //busco ppor el ID en la base de datos la entidad
                var entity = _sexoRepository.GetById(model.Id);                               
                entity.Deshabilitado = true;//Le cambiio el estado
                _sexoRepository.Update(entity); //Actualizo el repositorio
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
