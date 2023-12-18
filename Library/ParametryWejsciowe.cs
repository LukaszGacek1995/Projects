namespace Library
{
    internal class ParametryWejsciowe
    {
        public List<int> Wprowadzenie()
        {
            List<int> listaDanychWejsiowych = new List<int>();

            bool blednyZakresFlaga = false;

            while (!blednyZakresFlaga)
            {
                try
                {
                    Console.WriteLine("Wprowadź dwie liczby całkowite");
                    Console.WriteLine("Pierwsza n to ilość pozycji w bibliotece");
                    Console.WriteLine("Druga k to ilość zapytań");

                    string[] dane = Console.ReadLine().Split(' ');
                    int n, k;

                    if (dane.Length == 2 && int.TryParse(dane[0], out n) && int.TryParse(dane[1], out k))
                    {
                        if (n > 0 && n < 400001 && k > 0 && k < 200001)
                        {
                            listaDanychWejsiowych.Add(n);
                            listaDanychWejsiowych.Add(k);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Przekroczono zakres wartości, spróbuj jeszcze raz");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Błędny format danych, spróbuj jeszcze raz");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Wystąpił wyjątek: {ex.Message}, spróbuj ponownie");
                }
            }
            return listaDanychWejsiowych;
        }
    }
}
