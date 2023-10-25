# Flowsy Specification

## Concepts

The Specification Pattern is a design pattern used to encapsulate business rules or conditions and make them reusable and composable.

## ISpecification Interface
```csharp
public interface ISpecification<TCandidate>
{
    bool IsSatisfiedBy(TCandidate? candidate);
    
    SpecificationEvaluation<TCandidate> Evaluate(TCandidate? candidate);
    
    ISpecification<TCandidate> And(ISpecification<TCandidate> other);
    ISpecification<TCandidate> Or(ISpecification<TCandidate> other);
    ISpecification<TCandidate> Not();
}
```

Although you can implement this interface directly, the **AbstractSpecification** class provides
reusable functionality to simplify the process of creating your own specifications.


## Example
In the following example, the Customer entity holds information about a customer's credit limit and their outstanding balance:
```csharp
public class Customer
{
    public string Name { get; set; } = string.Empty;
    public decimal CreditLimit { get; set; }
    public decimal OutstandingBalance { get; set; }
}
```

Using specifications we can create reusable objects that tell us if our business rules are satisfied.

```csharp
public class CreditApprovalSpecification : AbstractSpecification<Customer>
{
    public override bool IsSatisfiedBy(Customer? candidate)
    {
        if (candidate is null)
            return false;
        
        return candidate.OutstandingBalance <= candidate.CreditLimit;
    }

    public override SpecificationEvaluation<Customer> Evaluate(Customer? candidate)
    {
        var isSatisfied = IsSatisfiedBy(candidate);
        var explanation = isSatisfied
            ? "Credit approval granted. Customer is eligible for additional credit."
            : $"Credit approval denied. Exceeded credit limit ({candidate?.CreditLimit}). Outstanding balance: {candidate?.OutstandingBalance}.";
        
        return new SpecificationEvaluation<Customer>(this, candidate, isSatisfied, explanation);
    }
}
```

And now we can reuse our business rules:
```csharp
public class Program
{
    public static void Main()
    {
        var customers = new List<Customer>();
        // Populate customer list
        var creditApproval = new CreditApprovalSpecification();

        foreach (var customer in customers)
        {
            var evaluation = creditApproval.Evaluate(customer);
            Console.WriteLine(
                @"Credit approved for customer {0}? {1} ({2})",
                customer.Name,
                evaluation.IsSatisfied ? "Yes" : "No",
                evaluation.Explanation
                );
        }
    }
}
```
