import { Component, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Transaction } from "../model/transaction.model";

@Component({
  selector: "transactions",
  templateUrl: "./transactions.component.html"
})

export class TransactionsComponent {
  public transactions: Transaction[];
  private url = "transactions";

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Transaction[]>(baseUrl + this.url).subscribe(result => {
      this.transactions = result;
    }, error => console.error(error));
  }
}
