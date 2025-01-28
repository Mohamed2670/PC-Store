declare global {
  interface Products {
    id: string;
    name: string;
    categoryId: string;
    currentPrice: number;
    storeId: number;
    imageUrl: string;
    productUrl: string;
  }
  interface Price {
    value: number;       
    productId: number;  
    date: string; 
  }
  interface ProductBuild{
    id: string;
    name: string;
    price: number;
    productUrl: string;
    buildCategory:string

  }
  
}

export {};
