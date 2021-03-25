import { Component, OnInit } from '@angular/core';
import { Words } from './words';
import { WordsService } from './words.service';
import { HttpErrorResponse } from '@angular/common/http';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent  {

  public name: string[];
  public words!: string[];
  public serverres!: string;
  public time!:number;
  public lefttime!:number;
  public commandRunning!: boolean;

  constructor(private wordService: WordsService){
    this.name=[];
    this.commandRunning=false;
  }

  // ngOnInit() {
  //   this.getWords();
  // }

  public getWords(): void {
    this.commandRunning=true;
    this.wordService.getWords().subscribe(
      (response: string[]) => {
        this.words = response;
        console.log(this.words);
        this.doTimer();
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );
  }

  public onAddWords(addWord:string): void {
    this.wordService.addWords(addWord).subscribe(
      (response: string[]) => {
        console.log(response);
        this.getList();
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );
  }

  public getList(): void {
    this.wordService.getList().subscribe(
      (response: string[]) => {
        this.name = response;
        console.log(this.name);
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );
  }

  public delay(delay: number) {
    return new Promise(r => {
        setTimeout(r, delay);
    })
  }

  async doTimer() {
    this.time=Math.floor(60000/this.words.length);
    this.lefttime=60000;
    for (let i = 0; i < this.words.length; i++) {
        this.lefttime=this.lefttime-this.time;
        this.serverres="Command Running: "+this.commandRunning+"\nCurrent Word Selected: "+this.words[i]+"\nCommand Time Remaining: "+this.lefttime+"ms";
        await this.delay(this.time);
    }
    this.commandRunning=false;
    this.serverres="Command Running: "+this.commandRunning;
}
  

}