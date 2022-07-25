import { Component, OnInit } from '@angular/core';
import { BsModalService, BsModalRef, ModalOptions } from 'ngx-bootstrap/modal';
import { CardComponent } from 'src/app/components/card/card.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  isCollapsed = true;
  bsModalRef?: BsModalRef;
  constructor(private modalService: BsModalService) {}

  openModalCard() {
    const initialState: ModalOptions = {
      initialState: {
        list: [
          'Open a modal with component',
          'Pass your data',
          'Do something else',
          '...',
        ],
        title: 'Modal with component',
      },
    };
    this.bsModalRef = this.modalService.show(CardComponent, initialState);
    this.bsModalRef.content.closeBtnName = 'Close';
  }

  ngOnInit(): void {}
}
