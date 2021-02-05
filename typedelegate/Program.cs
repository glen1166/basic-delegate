using System;
namespace typedelegate{

	class Program
	{
		static void Main(string[] args){
            var provider =	new TemperatureMonitor();
            var observer = new TemperatureReporter();
            observer.Subscribe(provider);
            provider.GetTemperature();
		}
	}
}
