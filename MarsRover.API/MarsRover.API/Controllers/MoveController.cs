using MarsRover.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace MarsRover.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoveController : ControllerBase
    {
        private ICommandCenter commandCenter;
        private ISurface surface;
        private IRover rover;

        public MoveController()
        {
        }

        /// <summary>
        /// Endpoint for proessing the command for moving the rover.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>See </returns>
        [HttpPost]
        public ResponseViewModel Move(InputViewModel model)
        {
            var response = new ResponseViewModel();
            if (!ValidateCommand(model.Commands))
            {
                response.Message = "Invalid Command";
                return response;
            }
            if (model.Surface != null)
                this.surface = new Surface(model.Surface.Width, model.Surface.Height);
            if (model.Position != null)
                this.rover = new Rover(new Position() { X = model.Position.X, Y = model.Position.Y, Direction = model.Position.Orientation });

            this.commandCenter = new CommandCenter(this.rover, this.surface);
            commandCenter.ExecuteCommands(model.Commands);
            response.Rovers = commandCenter.Steps;
            return response;
        }

        private bool ValidateCommand(string[] command)
        {
            //regex to check if the string contains other tha L, R, M
            var passed = true;
            foreach (var item in command)
            {
                if (!Regex.IsMatch(item, @"^[LRM]+$"))
                {
                    passed = false;
                    break;
                }
            }
            return passed;
        }
    }
}