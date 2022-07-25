import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { StatusCard } from 'src/app/models/StatusCard';
import { StatusCardService } from 'src/app/services/StatusCard.service';

@Component({
  selector: 'app-statusCard',
  templateUrl: './statusCard.component.html',
  styleUrls: ['./statusCard.component.scss'],
})
export class StatusCardComponent implements OnInit {
  modalRef?: BsModalRef;

  constructor(
    private statusCardService: StatusCardService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) {}

  public ngOnInit(): void {
    this.spinner.show();
    this.getStatusCards();
  }

  public statusCards: StatusCard[] = [];
  public statusCardFiltrados: StatusCard[] = [];

  private _filtroLista: string = '';

  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.statusCardFiltrados = this.filtroLista
      ? this.filtrarTitulos(this.filtroLista)
      : this.statusCards;
  }

  public filtrarTitulos(filtrarPor: string): StatusCard[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.statusCards.filter(
      (statusCards: any) =>
        statusCards.descricao.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  public getStatusCards(): void {
    const observer = {
      next: (statusCard: StatusCard[]) => {
        this.statusCards = statusCard;
        this.statusCardFiltrados = this.statusCards;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregar Status', 'Erro!');
      },
      complete: () => {
        this.spinner.hide();
      },
    };

    this.statusCardService.getStatusCards().subscribe(observer);
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.toastr.success('Status Card excluido com sucesso', 'Excluido!');
    this.modalRef?.hide();
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
