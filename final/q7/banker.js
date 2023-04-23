const { Mutex } = require('async-mutex');

const mutex = new Mutex();

class BankAccount {
  constructor() {
    this.balance = 0;
  }

  addMoney(amount) {
    this.balance += amount;
  }

  takeMoney(amount) {
    if (this.balance >= amount) {
      this.balance -= amount;
      return true;
    } else {
      return false;
    }
  }

  getBalance() {
    return this.balance;
  }
}

const bankAccount = new BankAccount();

function DepositThread() {
  setInterval(() => {
    mutex.acquire().then((release) => {
      const amount = Math.floor(Math.random() * 100) + 1;
      bankAccount.addMoney(amount);
      console.log(`Added $${amount} to the account. New balance: $${bankAccount.getBalance()}`);
      release();
    });
  }, 1000);
}

function WithdrawThread() {
  setInterval(() => {
    mutex.acquire().then((release) => {
      const amount = Math.floor(Math.random() * 100) + 1;
      if (bankAccount.takeMoney(amount)) {
        console.log(`Took out $${amount} from the account. New balance: $${bankAccount.getBalance()}`);
      } else {
        console.log(`Cannot take out $${amount} from the account. Insufficient funds.`);
      }
      release();
    });
  }, 1500);
}

for (let i = 0; i < 4; i++) {
    DepositThread();
}

for (let i = 0; i < 5; i++) {
    WithdrawThread();
}
