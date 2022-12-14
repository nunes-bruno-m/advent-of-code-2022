using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllDays.Day13
{
    internal class Decoder
    {
        public List<int> Run(IEnumerable<string> lines) 
        {
            List<int> list = new List<int>();
            var toSkip = 0;
            var idx = 1;
            do
            {
                var pairs = ReadPair(lines.Skip(toSkip).Take(3).ToList());

                toSkip += 3;

                if(!CompareLeftIsGreaterThanRight(pairs.left, pairs.right))
                {
                    list.Add(idx);
                }
                idx++;
            } while (toSkip < lines.Count());
            
            return list;
        }

        public (List<Signal> left, List<Signal> right) ReadPair(List<string> lines)
        {
            var firstSignals = new List<Signal>();
            var secondSignals = new List<Signal>();
            Parse(lines[0], firstSignals);
            Parse(lines[1], secondSignals);

            return (firstSignals, secondSignals);
        }

        public static List<char> NonValues = new List<char> { '[', ']', ',', ' ' };
        public void Parse(string signals, List<Signal> origin)
        {
            var currentSignalsList = origin;
            Signal currentSignal = null;
            char lastChar = ' ';
            for(var i = 0; i < signals.Length; i++)
            {
                if (signals[i] == '[')
                {
                    currentSignal = new Signal(currentSignalsList);
                    currentSignalsList.Add(currentSignal);
                    currentSignalsList = currentSignal.List;
                } else if(signals[i] == ']')
                {
                    currentSignalsList = currentSignal?.ParentList ?? currentSignalsList;
                } else if (signals[i] == ',')
                {
                    lastChar = signals[i];
                    continue;
                } else
                {
                    var value = int.Parse(signals[i].ToString());
                    
                    if(NonValues.Contains(lastChar) ) 
                    { 
                        currentSignal = new Signal(currentSignalsList);
                    } else
                    {
                        currentSignal.Value = currentSignal.Value.GetValueOrDefault() * 10;
                    }

                    currentSignal.Value = currentSignal.Value.GetValueOrDefault() + value;
                    currentSignalsList.Add(currentSignal);
                }
                lastChar = signals[i];
            }
        }

        public bool CompareLeftIsGreaterThanRight(List<Signal> left, List<Signal> right)
        {
            for(var i = 0; i < Math.Max(left.Count, right.Count); i++)
            {
                if (i == left.Count)
                    return false;

                if (i == right.Count)
                    return true;

                if (left[i].IsGreaterThan(right[i]))
                    return true;
            }
            return false;
        }
    }

    internal class Signal
    {
        public int? Value { get; set; }

        public Signal(int? value)
        {
            Value = value;
        }

        public List<Signal> List { get; set; } = new List<Signal>();
        public List<Signal> ParentList { get; set; }

        public Signal(List<Signal> parentList)
        {
            ParentList = parentList;
        }

        public Signal()
        {
        }

        public bool IsGreaterThan(Signal other)
        {
            if (other == null)
                return true;

            if(other.Value == null)
            {
                if(Value != null)
                {
                    List.Add(new Signal() { Value = Value });
                }
                return IsGreaterThan(other.List);
            } else
            {
                if(Value != null)
                {
                    return Value > other.Value;
                }

                other.List.Add(new Signal(other.Value));
                return IsGreaterThan(other.List);
            }
        }

        public bool IsGreaterThan(List<Signal> other) 
        {
            if (other == null)
                return true;
            
            if(List.Count < other.Count)
                return false;
            if (List.Count > other.Count)
                return true;

            for (var i = 0; i < List.Count; i++)
            {
                if (List[i].IsGreaterThan(other[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
