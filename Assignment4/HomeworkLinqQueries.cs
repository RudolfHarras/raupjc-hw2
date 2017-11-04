using System;
using System.Linq;
using Assignment1;

namespace Assignment4 {
	public class HomeworkLinqQueries {
		public static string[] Linq1(int[] intArray) {
			return intArray
				.GroupBy(num => num)
				.OrderBy(num => num.First())
				.Select(num => $"Broj {num.First()} ponavlja se {num.Count()} puta").ToArray();
		}

		public static University[] Linq2_1(University[] universityArray) {
			return universityArray
				.Where(uni => uni.Students.All(s => s.Gender.Equals(Gender.Male))).ToArray();
		}

		public static University[] Linq2_2(University[] universityArray) {
			return universityArray
				.Where(num => num.Students.Length < universityArray.Average(avg => avg.Students.Length)).ToArray();

		}

		public static Student[] Linq2_3(University[] universityArray) {
			return universityArray
				.SelectMany(stu => stu.Students).Distinct().ToArray();
		}

		public static Student[] Linq2_4(University[] universityArray) {
			return universityArray
				.Where(uni => uni.Students.All(s => s.Gender.Equals(Gender.Male))
				              ||
				              uni.Students.All(s => s.Gender.Equals(Gender.Female))
				)
				.SelectMany(un => un.Students.Select(s => s)).Distinct().ToArray();
		}

		public static Student[] Linq2_5(University[] universityArray) {
			return universityArray
				.SelectMany(uni => uni.Students
					.Where(uni2 => universityArray
						               .Count(uni3 => uni3.Students.Contains(uni2)) > 1))
				.Distinct().ToArray();
		}
	}
}