using System;
using System.Linq;
using System.Reflection;
using Buls.Interfaces;
using Buls.Data;
using Buls.Infrastructure;
using Buls.Models;
using Buls.Controllers;
using Buls.Views.Shared;
using Buls.Exceptions;
using System.Collections.Generic;

namespace Buls.Core
{
    public class BangaloreUniversityEngine : IEngine
    {
        private IBangaloreUniversityData dataBase;
        private IRenderer renderer;
        private IInputHandler inputHandler;
        private User currentUser;
        
        public BangaloreUniversityEngine(IBangaloreUniversityData dataBase, IRenderer renderer, IInputHandler inputHandler)
        {
            this.dataBase = dataBase;
            this.renderer = renderer;
            this.inputHandler = inputHandler;
            this.currentUser = null;
        }
        
        public void Run()
        {
            while (true)
            {
                string url = this.inputHandler.ReadLine();
                if (url == null)
                {
                    break;
                }

                if (url != string.Empty)
                {
                    IRoute route = new Route(url);

                    var controllerType = Assembly.GetExecutingAssembly().GetTypes()
                        .FirstOrDefault(type => type.Name == route.ControllerName);

                    var controller = Activator.CreateInstance(controllerType, dataBase, currentUser) as Controller;

                    var action = controllerType.GetMethod(route.ActionName);

                    object[] parameters = MapParameters(route, action);

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
                    //catch (AuthorizationFailedException ex)
                    //{
                    //    var errorView = new Error(ex.InnerException.Message);
                    //    viewResult = errorView.Display();
                    //}
                    //catch (ArgumentException ex)
                    //{
                    //    var errorView = new Error(ex.InnerException.Message);
                    //    viewResult = errorView.Display();
                    //}

                    this.renderer.WriteLine(viewResult);
                }
            }
        }

        private static object[] MapParameters(IRoute route, MethodInfo action)
        {
            //var parameters = action.GetParameters()
            //    .Select<ParameterInfo, object>(p => 
            //    {
            //        if (p.ParameterType == typeof(int))
            //        {
            //            return int.Parse(route.Parameters[p.Name]);
            //        }
            //        else
            //        {
            //            return route.Parameters[p.Name];
            //        }
            //    }).
            //    ToArray();
            
            //return parameters;

            var expectedMethodParameters = action.GetParameters();
            var argumentsToPass = new List<object>();
            
            foreach (ParameterInfo parameter in expectedMethodParameters)
            {
                var currentArgument = route.Parameters[parameter.Name];
                if (parameter.ParameterType == typeof(int))
                {
                    argumentsToPass.Add(int.Parse(currentArgument));
                }
                else
                {
                    argumentsToPass.Add(currentArgument);
                }
            }

            return argumentsToPass.ToArray();
        }
    }
}
