import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Painel } from 'src/app/models/Painel';
import { PaineisService } from 'src/app/services/Paineis.service';

@Component({
  selector: 'app-Painel',
  templateUrl: './Painel.component.html',
  styleUrls: ['./Painel.component.scss'],
})
export class PainelComponent implements OnInit {
  modalRef?: BsModalRef;

  constructor(
    private painelService: PaineisService,
    private modalService: BsModalService,
    private toastr: ToastrService
  ) {}

  public ngOnInit(): void {
    this.getPaineisCards();
  }

  public paineisCards: any[] = [];
  public paineisCardsFiltrados: any[] = [];

  private _filtroLista: number = 0;

  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(value: number) {
    this._filtroLista = value;
    this.paineisCardsFiltrados = this.filtroLista
      ? this.filtrarPaineisCards(this.filtroLista)
      : this.paineisCards;
  }

  public filtrarPaineisCards(filtrarPor: number): Painel[] {
    filtrarPor = filtrarPor;
    return this.paineisCards.filter(
      (paineisCards: any) => paineisCards.situacaoId.indexOf(filtrarPor) !== -1
    );
  }

  public getPaineisCards(): void {
    const observer = {
      next: (paineisCards: any[]) => {
        this.paineisCards = paineisCards;
        this.paineisCardsFiltrados = this.paineisCards;
      },
      error: (error: any) => console.log(error),
      complete: () => {},
    };

    this.painelService.getPaineis().subscribe(observer);
  }

  public insertColaborador(): void {}

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  modalInsert(templateInsert: TemplateRef<any>) {
    this.modalRef = this.modalService.show(templateInsert);
  }

  confirm(): void {
    this.toastr.success('Painel excluido com sucesso', 'Excluido!');
    this.modalRef?.hide();
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
