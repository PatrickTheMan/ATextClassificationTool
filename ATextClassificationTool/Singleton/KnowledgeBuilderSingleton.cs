using ATextClassificationTool.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATextClassificationTool.Singleton
{
	public sealed class KnowledgeBuilderSingleton : KnowledgeBuilder
	{
		private KnowledgeBuilderSingleton() { }
		private static KnowledgeBuilderSingleton instance = null;
		public static KnowledgeBuilderSingleton Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new KnowledgeBuilderSingleton();
				}
				return instance;
			}
		}
	}
}
