namespace Flowsy.Specification;

public interface ISpecificationEvaluation
{
    /// <summary>
    /// A value that indicates that the specification was satisfied.
    /// </summary>
    bool IsSatisfied { get; }
    
    /// <summary>
    /// A value that indicates that the specification was not satisfied.
    /// </summary>
    bool IsNotSatisfied { get; }
    
    /// <summary>
    /// A single message to describe the result of the evaluation.
    /// </summary>
    string Explanation { get; }
    
    /// <summary>
    /// A collection of messages to describe the result of the evaluation.
    /// </summary>
    IEnumerable<string> Explanations { get; }
}