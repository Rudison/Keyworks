import { SituacaoCard } from './SituacaoCard';
import { StatusCard } from './StatusCard';
import { Titulo } from './Titulo';

export interface Card {
  id: number;
  tituloId: number;
  statusId: number;
  situacaoId: number;
  nomeProjeto: string;
  dataPrevisao: Date;
  descricao: string;
  previsto: Date;
  saldo: Date;
  equipe: string;
  statusCard: StatusCard;
  titulo: Titulo;
  situacaoCard: SituacaoCard;
}
