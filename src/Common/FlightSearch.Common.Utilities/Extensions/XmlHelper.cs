using System.Xml.Linq;
using System.Xml.Serialization;

namespace FlightSearch.Common.Utilities.Extensions;

public static class XmlHelper
{
    public static TModel ConvertSoapXML<TModel>(this string xml) where TModel : class
    {
        var xmlDocument = XDocument.Parse(xml);

        var unwrappedResponse = xmlDocument.Descendants((XNamespace)"http://schemas.xmlsoap.org/soap/envelope/" + "Body").First().FirstNode;

        XmlSerializer serializer = new XmlSerializer(typeof(TModel));

        return (TModel)serializer.Deserialize(unwrappedResponse!.CreateReader())!;
    }
}