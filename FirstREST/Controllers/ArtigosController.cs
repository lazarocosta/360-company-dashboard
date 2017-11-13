﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Lib_Primavera.Model;


namespace FirstREST.Controllers
{
    public class ArtigosController : ApiController
    {
        //
        // GET: api/Artigos

        public IEnumerable<Lib_Primavera.Model.Artigo> Get()
        {
            return Lib_Primavera.PriIntegration.ListaArtigos();
        }

        //GET: api/artigos?dateDe=2014-12-12&dateAte=2017-12-12
        public IEnumerable<Lib_Primavera.Model.Artigo> Get( DateTime dataDe, DateTime dataAte)
        {
            return Lib_Primavera.PriIntegration.ListaArtigosDate( dataDe, dataAte);
        }


        // GET api/Artigos/A0001   
        public Artigo Get(string id)
        {
            Lib_Primavera.Model.Artigo artigo = Lib_Primavera.PriIntegration.GetArtigo(id);
            if (artigo == null)
            {
                throw new HttpResponseException(
                  Request.CreateResponse(HttpStatusCode.NotFound));
            }
            else
            {
                return artigo;
            }
        }

    }
}

