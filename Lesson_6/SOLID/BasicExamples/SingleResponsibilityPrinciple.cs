﻿//  Концепция SOLID — это набор принципов для разработки программного обеспечения, 
//	которые помогают делать код более гибким, понятным и поддерживаемым. 
//	Эти принципы особенно важны в больших проектах, чтобы избежать сложностей при изменении 
//	и добавлении функциональности.

namespace Lesson6.SOLID.BasicExamples
{
	// Problem:

	// Класс нарушает принцип единственной ответственности, так как он делает две вещи:
	// вычисляет зарплату и сохраняет сотрудника в БД.
	// Если нужно изменить способ сохранения данных или бизнес-логику расчета зарплаты,
	// это приведет к модификации одного и того же класса, что усложнит поддержку.

	public class Employee
	{
		public void CalculateSalary()
		{
			// Логика расчета зарплаты
		}

		public void SaveEmployee()
		{
			// Логика сохранения данных в БД
		}
	}

	// Solution:

	// Разделим ответственность. Один класс отвечает за логику зарплаты, а другой — за сохранение данных.

	public class EmployeeV2
	{
		public void CalculateSalary()
		{
			// Логика расчета зарплаты
		}
	}

	public class EmployeeRepository
	{
		public void SaveEmployee(EmployeeV2 employee)
		{
			// Логика сохранения данных в БД
		}
	}

	// Теперь класс Employee отвечает только за расчёт зарплаты, а класс EmployeeRepository — за сохранение данных.
}
