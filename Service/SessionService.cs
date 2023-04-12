using ASS_MVC.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using System.Web.Helpers;

namespace ASS_MVC.Service
{
	public static class SessionService
	{
		public static List<Product> GetProduct(ISession session, string key)
		{
			string jsondata = session.GetString(key);
			{
				if (jsondata == null)
				{
					return new List<Product>() { };
				}
				else
				{
					var datajson = JsonConvert.DeserializeObject<List<Product>>(jsondata);
					return datajson.ToList();
				}
			}
		}
		public static void SetProduct(ISession session, string key, object data)
		{
			var jsondata = JsonConvert.SerializeObject(data);
			session.SetString(key, jsondata);

		}
		public static bool CheckProduct(List<Product> products,Guid id)
		{
			return products.Any(p => p.Id == id);
		}
		public static void setuser(ISession session, string key, object data)
		{
			var jsondata=JsonConvert.SerializeObject(data);
			session.SetString(key,jsondata);
		}
		public static User getuser (ISession session, string key)
		{
			string jsondata =session.GetString(key);
			{
				if (jsondata == null)
				{
					return new User() {
						Id=Guid.NewGuid(),
						RoleId=Guid.Parse("0D7559E4-0DE2-4622-B154-909F3D1D179A"),
						Username="",
						Password="",
						Status=0,
					};
				}
				else
				{
					User datajson=(User)JsonConvert.DeserializeObject(jsondata);
					return datajson;
				}
			}
		}
	}
}
