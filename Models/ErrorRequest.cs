using Microsoft.AspNetCore.Mvc;

namespace WebApi.Models
{
    public class ErrorRequest
    {

        public string Message { get; set; }


        #region Constructores

        public ErrorRequest()
        {

        }

        public ErrorRequest(string message)
        {
            this.Message = message;

        }


        #endregion


        #region Metodos
        public JsonResult ToJson()
        {
            return new JsonResult(this);
        
        
        }



        #endregion
    }
}
