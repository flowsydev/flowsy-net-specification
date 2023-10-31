namespace Flowsy.Specification;

/// <summary>
/// Represents a domain specification that may or may not be satisfied by a given candidate.
/// </summary>
/// <typeparam name="TCandidate">The type of candidate for the specification.</typeparam>
public interface ISpecification<TCandidate>
{
    /// <summary>
    /// Indicates whether or not the specification is satisfied by the candidate.
    /// </summary>
    /// <param name="candidate">The candidate for the specification.</param>
    /// <returns>A boolean value.</returns>
    bool IsSatisfiedBy(TCandidate? candidate);
    
    /// <summary>
    /// Evaluates the specification on the given candidate.
    /// </summary>
    /// <param name="candidate">The candidate for the specification.</param>
    /// <returns>An instance of SpecificationEvaluation&lt;TCandidate&gt;.</returns>
    SpecificationEvaluation<TCandidate> Evaluate(TCandidate? candidate);
    
    /// <summary>
    /// Allows to evaluate this specification in conjunction with another one using the logical AND operator.   
    /// </summary>
    /// <param name="other">The other specification.</param>
    /// <returns>The resulting specification to be evaluated.</returns>
    ISpecification<TCandidate> And(ISpecification<TCandidate> other);
    
    /// <summary>
    /// Allows to evaluate this specification in conjunction with another one using the logical OR operator.   
    /// </summary>
    /// <param name="other">The other specification.</param>
    /// <returns>The resulting specification to be evaluated.</returns>
    ISpecification<TCandidate> Or(ISpecification<TCandidate> other);
    
    /// <summary>
    /// Allows to evaluate this specification as a logical negation.   
    /// </summary>
    /// <returns>The resulting specification to be evaluated.</returns>
    ISpecification<TCandidate> Not();
}