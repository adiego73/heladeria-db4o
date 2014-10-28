using System;

namespace Heladeria.db
{
	public abstract class HQuery<T>
	{
		abstract T build ();
	}
}

