﻿using System;

namespace LMConnect.Key
{
	public class Miner
	{
		public virtual Guid Id { get; set; }

		public virtual string MinerId { get; set; }

		public virtual string Path { get; set; }

		public virtual User Owner { get; set; }
	}
}
