using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManuaisTeste.Dal;
using ManuaisTeste.Models;

namespace ManuaisTeste.Controllers
{
    public class Movimento_ManualController : Controller
    {
        private ManualContext db = new ManualContext();

        // GET: Movimento_Manual
        public ActionResult Index()
        {
            var movimento_Manual = db.Movimento_Manual.Include(m => m.COD_COSIF).Include(m => m.COD_PRODUTO);
            return View(movimento_Manual.ToList());
        }

        // GET: Movimento_Manual/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimento_Manual movimento_Manual = db.Movimento_Manual.Find(id);
            if (movimento_Manual == null)
            {
                return HttpNotFound();
            }
            return View(movimento_Manual);
        }

        // GET: Movimento_Manual/Create
        public ActionResult Create()
        {
            ViewBag.COD_COSIFID = new SelectList(db.Produto_Cosif, "COD_COSIF", "COD_PRODUTOID");
            ViewBag.COD_PRODUTOID = new SelectList(db.Produto_Cosif, "COD_COSIF", "COD_PRODUTOID");
            return View();
        }

        // POST: Movimento_Manual/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DAT_MES,DAT_ANO,NUM_LANCAMENTO,COD_PRODUTOID,COD_COSIFID,DES_DESCRICAO,DAT_MOVIMENTO,COD_USUARIO,VAL_VALOR")] Movimento_Manual movimento_Manual)
        {
            if (ModelState.IsValid)
            {
                db.Movimento_Manual.Add(movimento_Manual);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_COSIFID = new SelectList(db.Produto_Cosif, "COD_COSIF", "COD_PRODUTOID", movimento_Manual.COD_COSIFID);
            ViewBag.COD_PRODUTOID = new SelectList(db.Produto_Cosif, "COD_COSIF", "COD_PRODUTOID", movimento_Manual.COD_PRODUTOID);
            return View(movimento_Manual);
        }

        // GET: Movimento_Manual/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimento_Manual movimento_Manual = db.Movimento_Manual.Find(id);
            if (movimento_Manual == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_COSIFID = new SelectList(db.Produto_Cosif, "COD_COSIF", "COD_PRODUTOID", movimento_Manual.COD_COSIFID);
            ViewBag.COD_PRODUTOID = new SelectList(db.Produto_Cosif, "COD_COSIF", "COD_PRODUTOID", movimento_Manual.COD_PRODUTOID);
            return View(movimento_Manual);
        }

        // POST: Movimento_Manual/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DAT_MES,DAT_ANO,NUM_LANCAMENTO,COD_PRODUTOID,COD_COSIFID,DES_DESCRICAO,DAT_MOVIMENTO,COD_USUARIO,VAL_VALOR")] Movimento_Manual movimento_Manual)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimento_Manual).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_COSIFID = new SelectList(db.Produto_Cosif, "COD_COSIF", "COD_PRODUTOID", movimento_Manual.COD_COSIFID);
            ViewBag.COD_PRODUTOID = new SelectList(db.Produto_Cosif, "COD_COSIF", "COD_PRODUTOID", movimento_Manual.COD_PRODUTOID);
            return View(movimento_Manual);
        }

        // GET: Movimento_Manual/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimento_Manual movimento_Manual = db.Movimento_Manual.Find(id);
            if (movimento_Manual == null)
            {
                return HttpNotFound();
            }
            return View(movimento_Manual);
        }

        // POST: Movimento_Manual/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movimento_Manual movimento_Manual = db.Movimento_Manual.Find(id);
            db.Movimento_Manual.Remove(movimento_Manual);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
