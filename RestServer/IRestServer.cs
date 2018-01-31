using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using ShapeData;

namespace ShapeRestServer
{
    [ServiceContract]
    public interface IRestServer
    {

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getCircle/{uuid}")]
        List<Circle> getCircle(string uuid);
        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteCircle/{uuid}")]
        ResultData deleteCircle(string uuid);
        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteshape/{uuid}")]
        ResultData deleteshape(string uuid);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "postCircle", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResultData postCircle();

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "addCircle")]
        ResultData addCircle(Circle rData);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "addCircles")]
        ResultData addCircles(List<Circle> rData);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "addShapes")]
        ResultData addShapes(TextFileInput input);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "calculateShapes/{uuid}")]
        string calculateShapes(string uuid);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getShapes/{uuid}")]
        ClassResult getShapes(string uuid);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getAllShapes")]
        List<ResultData> getAllShapes();

    }
}

