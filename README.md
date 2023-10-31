# Flowsy Specification

The Specification Pattern is a design pattern used to encapsulate business rules or conditions and make them reusable and composable.

## ISpecification\<TCandidate> Interface
Represents a domain specification that may or may not be satisfied by a given candidate.

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

## SpecificationEvaluation\<TCandidate>
Represents the results of evaluating a given specification.

```csharp
public class SpecificationEvaluation<TCandidate>
{
    public ISpecification<TCandidate> Specification { get; }
    public TCandidate? Candidate { get; }
    public bool IsSatisfied { get; }
    public string Explanation { get; }
}
```

## Example
Although you can implement the ISpecification\<TCandidate> interface directly, the **AbstractSpecification**
class provides reusable functionality to simplify the process of creating your own specifications.

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
    private readonly decimal _requestedCreditAmount;
    
    public CreditApprovalSpecification(decimal requestedCreditAmount)
    {
        _requestedCreditAmount = requestedCreditAmount;
    }
    
    public override bool IsSatisfiedBy(Customer? candidate)
    {
        if (candidate is null)
            return false;
        
        return candidate.OutstandingBalance + _requestedCreditAmount <= candidate.CreditLimit;
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
        const decimal creditAmount = 1000;
        var creditApproval = new CreditApprovalSpecification(creditAmount);

        foreach (var customer in customers)
        {
            var evaluation = creditApproval.Evaluate(customer);
            Console.WriteLine(
                @"${0} USD credit approved for customer {1}? {2} ({3})",
                creditAmount,
                customer.Name,
                evaluation.IsSatisfied ? "Yes" : "No",
                evaluation.Explanation
                );
        }
    }
}
```
