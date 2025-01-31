﻿using System.Collections.Generic;

using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using Agency.Exceptions;


namespace Agency.Commands
{
    public class CreateTrainCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3;

        public CreateTrainCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}");
            }

            int passengerCapacity = this.ParseIntParameter(base.CommandParameters[0], "passengerCapacity");
            double pricePerKilometer = this.ParseDoubleParameter(base.CommandParameters[1], "pricePerKilometer");
            int cartsCount = this.ParseIntParameter(base.CommandParameters[2], "cartsCount");

            var train = this.Repository.CreateTrain(passengerCapacity, pricePerKilometer, cartsCount);
            return $"Vehicle with ID {train.Id} was created.";
        }
    }
}
