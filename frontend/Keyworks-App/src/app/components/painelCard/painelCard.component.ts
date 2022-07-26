import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { PainelCard } from 'src/app/models/PainelCard';
import { PainelCardsService } from 'src/app/services/PainelCards.service';

@Component({
  selector: 'app-painelCard',
  templateUrl: './painelCard.component.html',
  styleUrls: ['./painelCard.component.scss'],
})
export class PainelCardComponent implements OnInit {
  modalRef?: BsModalRef;
  @Input() situacaoId: number = 0;

  constructor(
    private painelCardService: PainelCardsService,
    private modalService: BsModalService,
    private toastr: ToastrService
  ) {}

  public ngOnInit(): void {
    this.getPaineisCards();
  }

  public colorStatus: string = '';
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

  public filtrarPaineisCards(filtrarPor: number): PainelCard[] {
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

    this.painelCardService.getPaineisCard(this.situacaoId).subscribe(observer);
  }

  changeColorStatus(nomeStatus: string): string {
    if (nomeStatus == 'Em Dia') this.colorStatus = 'btn-success';
    else if (nomeStatus == 'Atenção') this.colorStatus = 'btn-warning';
    else if (nomeStatus == 'Em Atraso') this.colorStatus = 'btn-danger';

    return this.colorStatus;
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  modalInsert(templateInsert: TemplateRef<any>) {
    this.modalRef = this.modalService.show(templateInsert);
  }

  confirm(): void {
    this.toastr.success('Painel Card excluido com sucesso', 'Excluido!');
    this.modalRef?.hide();
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
