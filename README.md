# cart
My take on https://rubygem.me/2014/01/16/shopping-cart-kata/

Implement the code for a supermarket checkout that calculates the total price of a number of items. Goods are priced individually, however there are weekly special offers for when multiple items are bought. For example “Apples are 50 each or 3 for 130”.

Weekly offers change frequently.

|SKU   |Unit Price   |Special Offer   |
|------|-------------|----------------|          
|A99   |	         50|       3 for 130|
|B15   |	         30|        2 for 45|
|C40   |	         60|              	|
|T34   |   	       99|                |	

The checkout accepts the items in any order, so that if we scan a pack of Biscuits, an apple and another pack of biscuits, we’ll recognise two packs of biscuits and apply the discount of 2 for 45.

suggested interfaces (feel free to write your own!):

Javascript

var Checkout = function(){
  function total(){
  }
   
  function scan(item){
  }
 
  return {
    scan: scan,
    total: total
  };
};
