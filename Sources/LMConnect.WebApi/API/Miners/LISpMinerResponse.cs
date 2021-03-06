﻿using System.Xml.Linq;

namespace LMConnect.WebApi.API.Miners
{
	public class LISpMinerResponse : Response
	{
		public LISpMiner.LISpMiner LISpMiner { get; private set; }

		public LISpMinerResponse()
		{
		}

		public LISpMinerResponse(LISpMiner.LISpMiner miner)
		{
			this.LISpMiner = miner;
		}

		protected override XDocument XDocument
		{
			get
			{
				if (this.LISpMiner == null)
				{
					// TODO: list all miners
					return new XDocument(
						new XDeclaration("1.0", "utf-8", "yes"),
						new XElement("response",
						             new XAttribute("status", Status.Success.ToString().ToLower()),
						             new XElement("miners")
							)
						);
				}

				return new XDocument(
					new XDeclaration("1.0", "utf-8", "yes"),
					new XElement("response",
								new XAttribute("status", Status.Success.ToString().ToLower()),
								new XAttribute("id", this.LISpMiner.Id)
						)
					);
			}
		}
	}
}