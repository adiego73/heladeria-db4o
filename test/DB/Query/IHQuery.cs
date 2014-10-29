using System;

namespace Heladeria.db.query
{
	public interface IHQuery<T>
	{
		T build();
	}
}

