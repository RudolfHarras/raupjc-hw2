using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1
{
	public class Student {
		public string Name { get; set; }
		public string Jmbag { get; set; }
		public Gender Gender { get; set; }
		public Student(string name, string jmbag) {
			Name = name;
			Jmbag = jmbag;
		}



		public override bool Equals(object o) {
			if (ReferenceEquals(o, null)) return false;
			return Equals((Student)o);
		}

		public bool Equals(Student s) {
			if (ReferenceEquals(s, null)) return false;
			return s.Jmbag == this.Jmbag;
		}

		public override int GetHashCode() {
			return this.Jmbag.GetHashCode();
		}

		public static bool operator ==(Student a, Student b) {
			if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
			return a.Jmbag == b.Jmbag;
		}

		public static bool operator !=(Student a, Student b) {
			if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
			return a.Jmbag != b.Jmbag;
		}
	}
	
	public enum Gender {
		Male, Female
	}

}
