using System;
using System.Cli;
using System.IO;

namespace ConfuserExTools.ConstantKiller {
	public sealed class ConstantKillerSettings {
		private string _assemblyPath;
		private bool _preserveProxyMethods;
		private bool _preserveAll;
		private bool _ignoreAccess;

		[Argument("-f", IsRequired = true, Type = "FILE", Description = "程序集路径")]
		internal string AssemblyPathCliSetter {
			set => AssemblyPath = value;
		}

		[Argument("--preserve-proxies", Description = "是否保留代理方法")]
		internal bool PreserveProxyMethodsCliSetter {
			set => PreserveProxyMethods = value;
		}

		[Argument("--preserve-all", Description = "是否保留全部，仅还原代理方法")]
		internal bool PreserveAllCliSetter {
			set => PreserveAll = value;
		}

		[Argument("--ignore-access", Description = "是否忽略访问权限")]
		internal bool IgnoreAccessCliSetter {
			set => IgnoreAccess = value;
		}

		public string AssemblyPath {
			get => _assemblyPath;
			set {
				if (string.IsNullOrEmpty(value))
					throw new ArgumentNullException(nameof(value));
				if (!File.Exists(value))
					throw new FileNotFoundException($"{value} 不存在");

				_assemblyPath = Path.GetFullPath(value);
			}
		}

		public bool PreserveProxyMethods {
			get => _preserveProxyMethods;
			set => _preserveProxyMethods = value;
		}

		public bool PreserveAll {
			get => _preserveAll;
			set => _preserveAll = value;
		}

		public bool IgnoreAccess {
			get => _ignoreAccess;
			set => _ignoreAccess = value;
		}
	}
}
