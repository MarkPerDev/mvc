using PLCodeTest.Data;
using PLCodeTest.Service.Interfaces;
using System;

namespace PLCodeTest.Service
{
	public class BaseServices : IBaseServices, IDisposable
	{
		private HREntities _context = null;
		public HREntities DBContext
		{
			get
			{
				if (_context == null)
					_context = new HREntities();

				return _context;
			}

			set
			{
				this._context = value;
			}
		}
		#region Constructors

		/// <summary>
		/// An empty, default constructor that creates an instance of <see cref="BaseServices"/>.
		/// </summary>
		public BaseServices()
		{
			// Intentionally left empty.
		}

		/// <summary>
		/// Constructor builds an instance of <see cref="BaseServices"/> and
		/// populates the <see cref="_Context"/>.
		/// </summary>
		public BaseServices(HREntities pDbContext)
		{
			this._context = pDbContext;
		}

		#endregion Constructors


		#region IDisposable Implementation

		/// <summary>
		/// Releases the managed resources directly held by the current instance. i.e. The
		/// <<see cref="HREntities"/> used by this service is released, if it was
		/// instantiated internally by the current instance.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			// take this object off the finalization queue 
			// and prevent finalization code for this object
			// from executing a second time.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Conditionally releases the managed resources directly held by the current instance.
		/// i.e. The <see cref="HREntities"/> used by this service is released, if
		/// it was instantiated internally by the current instance.
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (this._context != null)
			{
				this._context.Dispose();
				this._context = null;
			}
		}

		#endregion IDisposable Implementation
	}
}
