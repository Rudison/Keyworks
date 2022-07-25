import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-TitulosTelas',
  templateUrl: './TitulosTelas.component.html',
  styleUrls: ['./TitulosTelas.component.scss'],
})
export class TitulosTelasComponent implements OnInit {
  @Input() nomeTitulo: string = '';
  @Input() iconClass: string = 'fa fa-user';
  @Input() subtitulo: string = '';
  @Input() botaoListar = false;
  constructor() {}

  ngOnInit() {}
}
