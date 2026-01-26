using System;

class Products
{
    Product[] product = new Product[5];
    public Products()
    {
        product[0] = new Product(1, "Laptop", 800.00, 0.1);
        product[1] = new Product(2, "Smartphone", 500.00, 0.05);
        product[2] = new Product(3, "Tablet", 300.00, 0.07);
        product[3] = new Product(4, "Monitor", 200.00, 0.15);
        product[4] = new Product(5, "Keyboard", 50.00, 0.2);
    }

    public Product[] sortByDiscount()
    {
        int n = product.Length;
        int[] discountArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            discountArray[i] = (int)(product[i].Discount * 100);
        }

        Sort sorter = new Sort();
        sorter.QuickSort(discountArray, 0, n - 1);

        Product[] sortedProducts = new Product[n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if ((int)(product[j].Discount * 100) == discountArray[i] && Array.IndexOf(sortedProducts, product[j]) == -1)
                {
                    sortedProducts[i] = product[j];
                    break;
                }
            }
        }

        return sortedProducts;
    }
}