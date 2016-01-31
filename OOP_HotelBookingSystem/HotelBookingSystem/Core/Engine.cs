using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using HotelBookingSystem.Data;
using HotelBookingSystem.Infrastructure;
using HotelBookingSystem.Models;
using HotelBookingSystem.Utilities;
using HotelBookingSystem.Views.Shared;
using HotelBookingSystem.Interfaces;

namespace HotelBookingSystem.Core
{
    public class Engine : IEngine
    {
        public Engine()
        {
        }
        
        public void StartOperation()
        {
            var database = new HotelBookingSystemData();
            IUser currentUser = null;
            while (true)
            {
                string url = Console.ReadLine();
                if (url == null)
                {
                    break;
                }

                IEndpoint executionEndpoint = new Endpoint(url);

                var controllerType = Assembly.GetExecutingAssembly().GetTypes()
                    .FirstOrDefault(type => type.Name == executionEndpoint.ControllerName);
                var action = controllerType.GetMethod(executionEndpoint.ActionName);
                object[] parameters = MapParameters(executionEndpoint, action);
                var controller = Activator.CreateInstance(controllerType, database, currentUser) as Controller;
                
                string viewResult = string.Empty;
                try
                {
                    var view = action.Invoke(controller, parameters) as IView;
                    viewResult = view.Display();
                    currentUser = controller.CurrentUser;
                }
                catch (TargetInvocationException ex)
                {
                    var errorView = new Error(ex.InnerException.Message);
                    viewResult = errorView.Display();
                }
                //catch (InvalidOperationException ex)
                //{
                //    var errorView = new Error(ex.InnerException.Message);
                //    viewResult = errorView.Display();
                //}

                Console.WriteLine(viewResult);
            }
        }

        private static object[] MapParameters(IEndpoint executionEndpoint, MethodInfo action)
        {
            var parameters = action
                .GetParameters()
                .Select<ParameterInfo, object>(p =>
                {
                    if (p.ParameterType == typeof(int))
                    {
                        return int.Parse(executionEndpoint.Parameters[p.Name]);
                    }
                    else if (p.ParameterType == typeof(decimal))
                    {
                        return decimal.Parse(executionEndpoint.Parameters[p.Name]);
                    }
                    else if (p.ParameterType == typeof(DateTime))
                    {
                        return DateTime.ParseExact(executionEndpoint.Parameters[p.Name], 
                            Constants.DateFormat, CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        return executionEndpoint.Parameters[p.Name];
                    }
                })
               .ToArray();

            return parameters;
        }
    }
}
