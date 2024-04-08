/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length == 0)
                    return 0; // Return 0 if the array is empty or null

                int k = 1; // Start with 1 as the first element is always unique
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] != nums[i - 1]) // Check if the current element is different from the previous one
                    {
                        nums[k] = nums[i]; // Move the unique element to the next position
                        k++; // Increment the count of unique elements
                    }
                }
                return k; // Return the count of unique elements
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions
            }
        }

        /*
         * Self-Reflection:
         
          I focused on an effective method for working with arrays and making in-place modifications, such as getting rid of duplicates without taking up more space.

          The significance of managing edge situations, like empty arrays or arrays with a single element, was further highlighted by this procedure. It's crucial to make sure the function works properly in every situation.

          This solution's efficiency stems from its linear time complexity, which makes it ideal for real-time applications and huge dataset operations. Efficiency is crucial since it directly affects performance, both in terms of process speed and memory utilization.

        */

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Write your code here
                if (nums == null || nums.Length <= 1)
                    return nums.ToList(); // Return the list if it's null or has only one element

                List<int> result = new List<int>(nums.Length);
                int nonZeroIndex = 0;

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0)
                    {
                        result.Add(nums[i]);
                        nonZeroIndex++;
                    }
                }

                while (nonZeroIndex < nums.Length)
                {
                    result.Add(0);
                    nonZeroIndex++;
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
         * Self-Reflection:
         This method helps with the core idea behind many array manipulations: moving components within an array without creating extra space.

         It involved traversing the array to move the nonzero items to the front and adding zeroes to the remaining positions. It was a good way of highlighting the necessity of practicing navigating an array with a variety of indexes.
         
        Issues at the margins Accounting time was also spent, just like in an array with fewer than two elements or an array with just zeros. To guarantee that the function operates correctly in every set of test cases, caution must be given. 
        
        This manages array operations efficiently, doing so in the most efficient manner to guarantee that the intended result is obtained without duplicates, either in space or location. useful only when dealing with arrays.
        */

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Write your code here
                IList<IList<int>> result = new List<IList<int>>(); // Initialize the result list

                if (nums == null || nums.Length < 3)
                    return result;

                Array.Sort(nums); // Sort the array in ascending order

                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Skip duplicates
                    if (i > 0 && nums[i] == nums[i - 1])
                        continue;

                    int left = i + 1; // Initialize the left pointer
                    int right = nums.Length - 1; // Initialize the right pointer

                    while (left < right)
                    {
                        int sum = nums[i] + nums[left] + nums[right]; // Calculate the sum of the triplet

                        if (sum == 0)
                        {
                            // Found a triplet with sum equal to zero
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });

                            // Skip duplicates
                            while (left < right && nums[left] == nums[left + 1])
                                left++;
                            while (left < right && nums[right] == nums[right - 1])
                                right--;

                            left++; // Move the left pointer to the right
                            right--; // Move the right pointer to the left
                        }
                        else if (sum < 0)
                        {
                            left++; // Move left pointer to increase sum
                        }
                        else
                        {
                            right--; // Move right pointer to decrease sum
                        }
                    }
                }
                return result; // Return the list of triplets
            }
            catch (Exception)
            {
                throw;
            }
        }


        /* * Self-Reflection:
         
          Some sophisticated array manipulation techniques, such as sorting the array and using multiple pointers to identify the triplet equal to zero, were utilized to overcome this problem.
        
          To prevent recomputation and so run quickly, the implementation required close attention, particularly in corner circumstances.

          In order to execute the solution, conditional statements are used to bypass the duplicate pointer adjustments and the one based on the total of elements, respectively. This further strengthened my ability to use conditional logic to algorithm solutions.

          This application of data structures, such the list for storing and retrieving the result set, makes me truly grateful for all the years I spent emphasizing data structures and giving advice on which data structure to choose in order to solve problems effectively. Improvements that primarily aimed to raise the overall efficiency of the solution were addressed, and the ongoing implementation work was maintained to minimize superfluous computations.
          
          In this approach, algorithm optimization has received a lot of attention for better performance.
        */

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                // Write your code here
                if (nums == null || nums.Length == 0)
                    return 0;

                int maxConsecutiveCount = 0; // Maximum consecutive count of 1's
                int currentConsecutiveCount = 0; // Current consecutive count of 1's

                foreach (int num in nums)
                {
                    if (num == 1)
                    {
                        // Increment current count for consecutive 1's
                        currentConsecutiveCount++;
                    }
                    else
                    {
                        // Update maximum count and reset current count when encountering 0
                        maxConsecutiveCount = Math.Max(maxConsecutiveCount, currentConsecutiveCount);
                        currentConsecutiveCount = 0;
                    }
                }

                // Update maxConsecutiveCount for the last sequence of consecutive 1's
                maxConsecutiveCount = Math.Max(maxConsecutiveCount, currentConsecutiveCount);

                return maxConsecutiveCount;
            }
            catch (Exception)
            {
                throw;
            }
        }



        /* 
           * Self-Reflection:
         
          Using an effective array iteration to update the count of elements encountered was the workaround.

          The result will make it possible to maintain and monitor each site of recurrence for the 1s in that binary array. The methodical and sequential element counting of the algorithmic solutions was motivated by this understanding. 

          For example, the solution has been carefully considered so that the function won't take extra care for any edge cases when an array contains only one element or all zeros.

          The optimal time complexity can be obtained when counts are updated efficiently while traversing an array, suggesting that highly efficient techniques should be properly taken into account.
         */

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                // Write your code here
                if (binary == 0)
                    return 0; // If the binary number is 0, return 0

                int decimalValue = 0; // Initialize the decimal value to 0
                int baseValue = 1; // Initialize the base value to 1

                while (binary != 0)
                {
                    int lastDigit = binary % 10; // Extract the last digit of the binary number
                    binary /= 10; // Remove the last digit from the binary number

                    decimalValue += lastDigit * baseValue; // Update the decimal value
                    baseValue *= 2; // Update the base value (power of 2)
                }

                return decimalValue;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* 
           * Self-Reflection:

           Applying fundamental arithmetic operations to transform a binary integer into a decimal representation, the solution's implementation increased my grasp of number systems.

           Notably, the required conversion may be found with just a few simple mathematical operations, making the solution simple and easy to understand. This does not depend on exponentiation-based functions or bit operator operations.

           It is clearly seen that the given decimal value in each iteration of the binary digit loop emphasizes and amplifies the efficiency of algorithms in solving issues.
 
           Working with binary numbers in these scenarios always facilitated the transformation process and highlighted the importance of numerical operations in algorithmic solutions.

         */

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.


        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                // Write your code here
                if (nums == null || nums.Length < 2)
                    return 0;

                // Find the minimum and maximum elements in the array
                int minElement = int.MaxValue;
                int maxElement = int.MinValue;
                foreach (int num in nums)
                {
                    minElement = Math.Min(minElement, num);
                    maxElement = Math.Max(maxElement, num);
                }

                // Calculate the minimum possible gap
                int minGap = (int)Math.Ceiling((double)(maxElement - minElement) / (nums.Length - 1));

                // Create buckets to store elements
                int numBuckets = (maxElement - minElement) / minGap + 1;
                int[] minBucket = new int[numBuckets];
                int[] maxBucket = new int[numBuckets];
                Array.Fill(minBucket, int.MaxValue);
                Array.Fill(maxBucket, int.MinValue);

                // Distribute numbers into buckets
                foreach (int num in nums)
                {
                    int index = (num - minElement) / minGap;
                    minBucket[index] = Math.Min(minBucket[index], num);
                    maxBucket[index] = Math.Max(maxBucket[index], num);
                }

                // Find the maximum gap between successive non-empty buckets
                int maxGap = 0;
                int previousMax = maxBucket[0];
                for (int i = 1; i < numBuckets; i++)
                {
                    if (minBucket[i] != int.MaxValue)
                    {
                        maxGap = Math.Max(maxGap, minBucket[i] - previousMax);
                        previousMax = maxBucket[i];
                    }
                }

                return maxGap;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /* * Self-Reflection:
         
         * 
         Using mathematical concepts, such as determining the distance between elements and distributing numbers into buckets, proved to be the optimal solution strategy. This approach highlighted the importance of applying mathematical principles effectively when tackling algorithmic problems.

         It's crucial to ensure that the algorithm's time complexity remains linear and that it utilizes additional space efficiently. Emphasizing algorithmic efficiency is fundamental to achieving overall efficiency.

         Handling edge cases, such as arrays with fewer than two elements, demonstrated the necessity of addressing various scenarios to ensure the algorithm functions flawlessly in all circumstances. This underscores the importance of considering constraints while designing algorithms.

         The process of distributing elements across buckets and calculating the gaps between them underscored the significance of manipulating the array effectively to achieve the desired outcome.

         Overall, the study highlighted the importance of designing algorithms that adhere to constraints, such as maintaining linear time complexity and utilizing linear additional space, to ensure optimal performance.
         */

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Write your code here
                if (nums == null || nums.Length < 3)
                    return 0; // If the array is null or has less than 3 elements, no valid triangle can be formed

                Array.Sort(nums); // Sort the array in non-decreasing order

                for (int i = nums.Length - 1; i >= 2; i--) // Iterate from right to left
                {
                    int sideA = nums[i - 2];
                    int sideB = nums[i - 1];
                    int sideC = nums[i];
                    if (sideA + sideB > sideC) // Check if a valid triangle can be formed
                    {
                        return sideA + sideB + sideC; // Return the perimeter of the triangle
                    }
                }

                return 0; // No valid triangle can be formed
            }
            catch (Exception)
            {
                throw;
            }
        }


        /* 
         * Self-Reflection:
         
           I was aware that the triangle inequality theorem may be used during implementation to determine whether the given side lengths could be used to create a triangle with a non-zero area. It made it easier for me to connect my knowledge of geometry with geometric ideas found in algorithmic solutions.

           The algorithm's design is fairly clean and effective, with the straightforward and efficient method of iterating through the sorted array to check for valid triangles being easily accessible.

           By using these geometric concepts, the fundamental application had shed light on the necessity of using mathematical concepts consistently and the multidisciplinary nature of effective algorithm design.
         */

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                int startIndex;
                while ((startIndex = s.IndexOf(part)) != -1)
                {
                    // Remove the leftmost occurrence of the substring part
                    s = s.Remove(startIndex, part.Length);
                }
                return s;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /* * Self-Reflection:

            Once the fix was put into practice, I was able to work with strings once more when I used techniques like IndexOf and Remove to locate and remove instances of substrings that reminds of how algorithmic solutions handle strings.

            This approach uses a while loop to detect the substring in the input string from left to right and remove it one at a time. This strategy proves to be accurate in providing a fast and efficient means of finishing a tedious task.
            
            This ensures the function operates correctly and robustly, avoiding the requirement for the algorithm design to incorporate even more robust error handling. It helps prevent string manipulation mistakes by handling exceptions that might be thrown during string manipulation, including the 'index out of range' issue. They modified strings using built-in routines in a few different ways to get rid of substrings. This was carefully considered to make the most of the language-optimized features while putting good algorithms in place.

                
         */


        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}