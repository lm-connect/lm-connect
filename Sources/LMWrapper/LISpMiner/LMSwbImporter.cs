using System;
using System.Text;

namespace LMWrapper.LISpMiner
{
	/// <summary>
	/// Imports PMML file into the metabase (transformation dictionary, tasks) 
	/// </summary>
	public class LMSwbImporter : Executable
	{
		/// <summary>
		/// /Alias:[alias_file]  ... aliases for text strings (for PMML mainly)
		/// </summary>
		public string Alias { get; set; }

		/// <summary>
		/// /Input:[pmml_file] ... input PMML file with definitions
		/// </summary>
		public string Input { get; set; }

		/// <summary>
		/// skip test of unique values in the database table primary key
		/// </summary>
		public bool NoCheckPrimaryKeyUnique { get; set; }

		public override string Arguments
		{
			get
			{
				var arguments = new StringBuilder("");

				if (!String.IsNullOrEmpty(this.Dsn))
				{
					arguments.AppendFormat("\"/DSN:{0}\" ", this.Dsn);
				}

				// /Input:<pmml_file>
				if (!String.IsNullOrEmpty(this.Input))
				{
					arguments.AppendFormat("\"/Input:{0}\" ", this.Input);
				}

				// /Alias:<alias_file>
				if (!String.IsNullOrEmpty(this.Alias))
				{
					arguments.AppendFormat("\"/Alias:{0}\" ", this.Alias);
				}

				// /NoCheckPrimaryKeyUnique
				if (this.NoCheckPrimaryKeyUnique)
				{
					arguments.Append("/NoCheckPrimaryKeyUnique ");
				}

				// /Quiet
				if (this.Quiet)
				{
					arguments.Append("/Quiet ");
				}

				// /NoProgress
				if (this.NoProgress)
				{
					arguments.Append("/NoProgress ");
				}

				// /AppLog
				if (!String.IsNullOrEmpty(this.AppLog))
				{
					arguments.AppendFormat("\"/AppLog:{0}\"", this.AppLog);
				}

				return arguments.ToString().Trim();
			}
		}

		public LMSwbImporter()
			: base()
		{
			this.ApplicationName = "LMSwbImporter.exe";
			this.AppLog = String.Format("{0}-{1}.dat", "_AppLog_importer", Guid.NewGuid());
		}
	}
}