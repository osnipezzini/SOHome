using System;

namespace SOHome.Common.Exceptions
{

	[Serializable]
	public class ExerciseConflictException : Exception
	{
		public ExerciseConflictException() { }
		public ExerciseConflictException(string message) : base(message) { }
		public ExerciseConflictException(string message, Exception inner) : base(message, inner) { }
		protected ExerciseConflictException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
