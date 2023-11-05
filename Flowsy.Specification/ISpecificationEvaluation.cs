namespace Flowsy.Specification;

public interface ISpecificationEvaluation
{
    /// <summary>
    /// A value that indicates the satisfaction or failure of the evaluation.
    /// </summary>
    bool IsSatisfied { get; }
    
    /// <summary>
    /// A message to describe the result of the evaluation.
    /// </summary>
    string Explanation { get; }
}