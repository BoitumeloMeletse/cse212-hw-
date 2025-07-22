using System;
using System.Collections;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Recursively compute 1^2 + 2^2 + ... + n^2.
    /// If n <= 0, return 0. No loops.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Insert all permutations of length 'size' chosen from 'letters'
    /// into results. 'word' accumulates the current prefix.
    /// Example: letters="ABCD", size=2 → AB, AC, AD, BA, ...
    /// Order doesn't matter (tests sort).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // When we've chosen 'size' letters, add the built word.
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Choose each remaining letter in turn and recurse on the rest.
        for (int i = 0; i < letters.Length; i++)
        {
            char c = letters[i];
            // Remove the chosen char from the candidate pool
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + c);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count the number of ways to climb 's' stairs if you can
    /// take 1, 2, or 3 steps at a time. Use memoization for speed.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        remember ??= new Dictionary<int, decimal>();

        if (remember.TryGetValue(s, out decimal cached))
            return cached;

        // Base cases (match assignment spec & test expectations)
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;
        if (s < 0) return 0; // defensive

        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Expand a pattern containing '0','1','*' wildcards into all
    /// concrete binary strings and add them to results.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int star = pattern.IndexOf('*');
        if (star == -1)
        {
            // No wildcard: pattern is a completed string (even "" is valid).
            results.Add(pattern);
            return;
        }

        // Replace the '*' with '0' and recurse
        string withZero = pattern.Substring(0, star) + "0" + pattern[(star + 1)..];
        WildcardBinary(withZero, results);

        // Replace the '*' with '1' and recurse
        string withOne = pattern.Substring(0, star) + "1" + pattern[(star + 1)..];
        WildcardBinary(withOne, results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Find all (x,y) paths from start (0,0) to the 'end' cell (value 2)
    /// in the given Maze. Use recursion + backtracking. Paths are tracked
    /// in 'currPath' and converted to string via currPath.AsString().
    /// </summary>
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<ValueTuple<int, int>>? currPath = null)
    {
        // First-call setup
        currPath ??= new List<ValueTuple<int, int>>();

        // Validate move before committing
        if (!maze.IsValidMove(currPath, x, y))
            return;

        // Add this square to the current path
        currPath.Add((x, y));

        // Check for success
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1); // backtrack
            return;
        }

        // Explore neighbors (order doesn't matter; tests sort results)
        SolveMaze(results, maze, x + 1, y, currPath); // right
        SolveMaze(results, maze, x - 1, y, currPath); // left
        SolveMaze(results, maze, x, y + 1, currPath); // down
        SolveMaze(results, maze, x, y - 1, currPath); // up

        // Backtrack when all branches from this square are done
        currPath.RemoveAt(currPath.Count - 1);
    }
}
