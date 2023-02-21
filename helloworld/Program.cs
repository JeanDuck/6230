using System.Diagnostics;
//Write code in any language which will create 4 threads and run them in parallel.
// create 4 threads
Console.WriteLine("question1");
Thread thread1 = new Thread(new ThreadStart(Thread1));
Thread thread2 = new Thread(new ThreadStart(Thread2));
Thread thread3 = new Thread(new ThreadStart(Thread3));
Thread thread4 = new Thread(new ThreadStart(Thread4));
// start the threads
thread1.Start();
thread2.Start();
thread3.Start();
thread4.Start();

// wait for all threads to complete
thread1.Join();
thread2.Join();
thread3.Join();
thread4.Join();

Console.WriteLine("All threads have completed.");


static void Thread1()
{
    Console.WriteLine("Thread one started.");
    Console.WriteLine("Thread one completed.");
}

static void Thread2()
{
    Console.WriteLine("Thread two started.");
    Console.WriteLine("Thread two completed.");
}

static void Thread3()
{
    Console.WriteLine("Thread three started.");
    Console.WriteLine("Thread three completed.");
}

static void Thread4()
{
    Console.WriteLine("Thread four started.");
    Console.WriteLine("Thread four completed.");
}

// Write code in any language which will write code to Multiply every value in a array with Random value between 0.1 to 0.9 Calculate the sum of the array in parallel and serial and compute the time difference. 
Console.WriteLine(" ");
Console.WriteLine("question2");

int[] arr = new int[1000000]; // an array of size 10 million
Random random = new Random();
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = random.Next(100); // fill the array with random integers
}
int[] serialOfRes = new int[arr.Length];
int[] parallelOfRes = new int[arr.Length];

double[] randomVal = new double[arr.Length];

for (int i = 0; i < arr.Length; i++)
{
    //generate a random value between 0.1 and 0.9, multiply every value in the array with a random value between 0.1 and 0.9
    randomVal[i] = random.NextDouble() * 0.8 + 0.1;
    arr[i] = (int)(arr[i] * randomVal[i]);
}

//calculate the time needed for serial
Stopwatch timer = new Stopwatch();
timer.Start();
int sumSerial = 0;
for (int i = 0; i < arr.Length; i++)
{
    sumSerial += arr[i];
}
timer.Stop();
//the time needed for serial
long timeOfSerial = timer.ElapsedMilliseconds;

//calculate the time needed for parallel
timer.Restart();
int sumParallel = 0;
Parallel.For(0, arr.Length, i =>
{
    Interlocked.Add(ref sumParallel, arr[i]);
});
timer.Stop();
long timeOfParallel = timer.ElapsedMilliseconds;

Console.WriteLine("Serial Sum: " + sumSerial + ", Time: " + timeOfSerial + "ms");
Console.WriteLine("Parallel Sum: " + sumParallel + ", Time: " + timeOfParallel + "ms");
/**
In general, parallel processing is most effective when there are multiple processors or cores available, and when the workload can be effectively split among multiple threads. For smaller arrays or systems with a single processor, the overhead of creating and managing threads can sometimes outweigh the performance benefits of parallel processing.
*/
Console.WriteLine("time difference: " + (timeOfParallel - timeOfSerial) + "ms");