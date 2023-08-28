﻿using BLL.DTOs;
using BLL.Services;
using E_Learning.AuthFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_Learning.Controllers
{
    public class ParentController : ApiController
    {
        [Teacher]
        [HttpPost]
        [Route("api/Parent/add")]
        public HttpResponseMessage Add(ParentDTO obj)
        {
            try
            {
                var data = ParentService.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        [HttpGet]
        [Route("api/Parent/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = ParentService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        [Teacher]
        [HttpGet]
        [Route("api/Parent/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = ParentService.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "deleted" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Teacher]
        [HttpPost]
        [Route("api/Parent/update")]
        public HttpResponseMessage update(ParentDTO obj)
        {
            try
            {
                var data = ParentService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Parent/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = ParentService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Parent/title/{name}")]
        public HttpResponseMessage GetByName(string name)
        {
            try
            {
                var data = false;
                if (data == true)
                {
                    ParentService.GetByName(name);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Found" });
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Parent/student/{studentName}")]
        public HttpResponseMessage GetParentDetailsByStudentName(string studentName)
        {
            try
            {
                var data = StudentService.GetParentDetailsByStudentName(studentName);
                if (data.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Not Found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Student/parent/{studentId}")]
        public HttpResponseMessage GetParentByStudentId(int studentId)
        {
            try
            {
                var parent = StudentService.GetParentByStudentId(studentId);

                if (parent == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Student not found" });
                }

                return Request.CreateResponse(HttpStatusCode.OK, parent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
