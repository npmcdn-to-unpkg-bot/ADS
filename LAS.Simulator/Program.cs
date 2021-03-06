﻿using System;
using LAS.Core.Utils;
using NLog;
using Itinero.LocalGeo;
using System.Collections.Generic;
using PetaPoco;
using System.Configuration;
using System.Threading;

namespace LAS.Simulator
{
	class MainClass
	{
		static readonly Logger logger = LogManager.GetCurrentClassLogger();



		public static void Main(string[] args)
		{
			logger.Info("Starting simulator");
			var connectionString = ConfigurationManager.ConnectionStrings["postgres"].ConnectionString;
			var provider = new PostgreSQLDatabaseProvider();

			var config = DatabaseConfiguration.Build()
										  .UsingConnectionString(connectionString)
										  .UsingProvider(provider)
										  .UsingDefaultMapper<ConventionMapper>();

			var incSimulator = new IncidentSimulator(new Database(config));

			var mapService = new MapService();
			var hospitals = new Dictionary<string, Coordinate>();
			hospitals.Add("HOP1", new Coordinate(50.834957f, 4.348430f));
			hospitals.Add("HOP2", new Coordinate(50.814250f, 4.357530f));
			hospitals.Add ("HOP3",  new Coordinate(50.853853f, 4.360663f));
			hospitals.Add ("HOP4",  new Coordinate(50.852575f, 4.452851f));
			hospitals.Add ("HOP5",  new Coordinate(50.845607f, 4.317075f));
			hospitals.Add ("HOP6",  new Coordinate(50.804648f, 4.367769f));
			hospitals.Add ("HOP7",  new Coordinate(50.825022f, 4.379507f));
			hospitals.Add ("HOP8",  new Coordinate(50.813997f, 4.259632f));
			//hospitals.Add ("HOP8",  new Coordinate(50.8128775f, 4.2649523f));
			hospitals.Add ("HOP9",  new Coordinate(50.905819f, 4.390159f));
			hospitals.Add ("HOP10", new Coordinate(50.8885403f, 4.3288842f));
			hospitals.Add ("HOP11", new Coordinate(50.833261f, 4.347095f));
			hospitals.Add ("HOP12", new Coordinate(50.8872628f, 4.3089256f));
			hospitals.Add ("HOP13", new Coordinate (50.842471f, 4.399073f));

			var pasiDelta = new Coordinate(50.818754f, 4.402740f);
			var hopIxelles = new Coordinate(50.824938f, 4.379172f);
			var pasiAnderlecht = new Coordinate(50.832740f, 4.311812f);
			var pasiEvere = new Coordinate(50.870964f, 4.417631f);
			var pasiVUB = new Coordinate(50.890831f, 4.308449f);
			var pasiChenaie = new Coordinate(50.783341f, 4.356218f);
			var pasiCite = new Coordinate(50.849709f, 4.361116f);
			var pasiUCL = new Coordinate(50.851937f, 4.460279f);
			var heliport = new Coordinate(50.859485f, 4.351848f);
			var moliere = new Coordinate(50.815206f, 4.342141f);
			var saintpierre = new Coordinate(50.835228f, 4.348342f);

			logger.Info("Adding ambulances");

			var a01 = new SimulatedAmbulance("A1", mapService, hospitals, pasiAnderlecht);
			var a02 = new SimulatedAmbulance("A2", mapService, hospitals, pasiDelta);
			var a03 = new SimulatedAmbulance("A3", mapService, hospitals, pasiVUB);
			var a04 = new SimulatedAmbulance("A4", mapService, hospitals, pasiCite);
			var a05 = new SimulatedAmbulance("A5", mapService, hospitals, pasiVUB);
			var a06 = new SimulatedAmbulance("A6", mapService, hospitals, heliport);
			var a07 = new SimulatedAmbulance("A7", mapService, hospitals, heliport);
			var a08 = new SimulatedAmbulance("A8", mapService, hospitals, heliport);
			var a09 = new SimulatedAmbulance("A9", mapService, hospitals, hopIxelles);
			var a10 = new SimulatedAmbulance("A10", mapService, hospitals, pasiUCL);
			var a11 = new SimulatedAmbulance("A11", mapService, hospitals, pasiUCL);
			var a12 = new SimulatedAmbulance("A12", mapService, hospitals, pasiCite);
			var a13 = new SimulatedAmbulance("A13", mapService, hospitals, moliere);
			var a14 = new SimulatedAmbulance("A14", mapService, hospitals, pasiVUB);
			var a15 = new SimulatedAmbulance("A15", mapService, hospitals, pasiDelta); 
			//var a16 = new SimulatedAmbulance("A16", mapService, hospitals, saintpierre);
			//var a17 = new SimulatedAmbulance("A17", mapService, hospitals, heliport);
			//var a18 = new SimulatedAmbulance("A18", mapService, hospitals, pasiChenaie);
			//var a19 = new SimulatedAmbulance("A19", mapService, hospitals, pasiChenaie);
			//var a20 = new SimulatedAmbulance("A20", mapService, hospitals, saintpierre);
			//var a21 = new SimulatedAmbulance("A21", mapService, hospitals, saintpierre);
			//var a22 = new SimulatedAmbulance("A22", mapService, hospitals, pasiEvere);
			//var a23 = new SimulatedAmbulance("A23", mapService, hospitals, pasiEvere);
			//var a24 = new SimulatedAmbulance("A24", mapService, hospitals, pasiEvere);
			//var a25 = new SimulatedAmbulance("A25", mapService, hospitals, pasiCite);
			//var a26 = new SimulatedAmbulance("A26", mapService, hospitals, pasiCite);

			logger.Info("Ambulances added");

			Thread.Sleep(TimeSpan.FromSeconds (5));
			incSimulator.Start();
		}


	}
}
