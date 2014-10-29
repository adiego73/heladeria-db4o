using System;
using System.Collections.Generic;
using Db4objects.Db4o.Query;

namespace Heladeria.db.query
{
	public interface IHQuery<T>
	{
		T build();
	}
}

