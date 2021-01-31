using System;
using System.ComponentModel;
namespace eventproperty{

	class Program
	{
		static void Main(string[] args){
			SampleControl control = new SampleControl();
			control.LightWentOn += (obj, para)=>{
				Console.WriteLine("light went on.");
			};

			control.LightWentOut += (obj, para)=>{
				Console.WriteLine("light went out.");
			};
			
			control.FireEvent();
		}
	}

	public	class SampleControl : Component
	{

		protected EventHandlerList listEventDelegates = new EventHandlerList();

		// Define a unique key for each event.
		static readonly object lightWentOn = new object();
		static readonly object lightWentOut = new object();

		public event EventHandler LightWentOn
		{
			// Add the input delegate to the collection.
			add
			{
				listEventDelegates.AddHandler(lightWentOn, value);
			}
			// Remove the input delegate from the collection.
			remove
			{
				listEventDelegates.RemoveHandler(lightWentOn, value);
			}
		}

		private void OnLightWentOn(EventArgs e)
		{
			EventHandler lightWentOnDelegate = (EventHandler)listEventDelegates[lightWentOn];
			lightWentOnDelegate(this, e);
		}

		public event EventHandler LightWentOut
		{
			// Add the input delegate to the collection.
			add
			{
				listEventDelegates.AddHandler(lightWentOut, value);
			}
			// Remove the input delegate from the collection.
			remove
			{
				listEventDelegates.RemoveHandler(lightWentOut, value);
			}
		}

		private void OnLightWentOut(EventArgs e)
		{
			EventHandler lightWentOutDelegate = (EventHandler)listEventDelegates[lightWentOut];
			lightWentOutDelegate(this, e);
		}

		public void FireEvent(){
			var arg = new EventArgs();
			OnLightWentOn(arg);
			OnLightWentOut(arg);
		}
	}
}
