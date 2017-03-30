using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Interface
{
	public enum PowerUpTypes
	{
		a,
		b
	}

	public interface IPowerUp
	{
		PowerUpTypes type { get; }
	}
}
